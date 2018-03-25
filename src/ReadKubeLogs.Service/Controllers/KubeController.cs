using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using k8s;
using k8s.Models;
using System.Text;

namespace ReadKubeLogs.Service.Controllers
{
    [Route("api/[controller]")]
    public class KubeController : Controller
    {
        IKubernetes kubeClient;
        public KubeController(IKubernetes client)
        {
            
            kubeClient = client;
        }
        /// <summary>
        /// This API gets the log (Kubectl log) by taking the podName and namespace name
        /// </summary>
        /// <param name="podName">Kubenetes POD for which log has to be read</param>
        /// <param name="namespaceName">Name of the Namespace in which the POD resides</param>
        /// <returns>JSON containing the Kube Log</returns>
        
        [HttpGet("{podName}/{namespaceName}")]
        public async Task<IActionResult> Get(string  podName, string namespaceName)
        {
            string content;
            var _namespaceName = (string.IsNullOrWhiteSpace(namespaceName)) ? "default" : namespaceName;
            //var list = kubeClient.ListNamespacedPod("default");
            using (var stream = await kubeClient.ReadNamespacedPodLogAsync(podName, _namespaceName))
            {

                using (StreamReader reader = new StreamReader(stream))
                {
                    content =  reader.ReadToEnd();
                    Console.WriteLine(content);
                }
                stream.Flush();
            }
            return Json(content);
        }
        /// <summary>
        /// This API gets the log (Kubectl log) by taking the Service name and namespace name
        /// </summary>
        /// <param name="serviceName">Name of the service for which log is needed</param>
        /// <param name="namespaceName">Name space name of the service for which log s needed</param>
        /// <returns>JSON array of logs from all PODS that runds beneath the service</returns>
        [HttpGet("ServiceLog/{serviceName}/{namespaceName}")]
        public  async Task<IActionResult> GetServiceLog(string serviceName, string namespaceName)
        {
            V1Service services = kubeClient.ReadNamespacedService(serviceName, namespaceName);
            var serviceLabels = services.Metadata.Labels;
            StringBuilder labelQueryBuilder = new StringBuilder();
            foreach(KeyValuePair<string,string>dictEntry in serviceLabels)
            {
                if (labelQueryBuilder.Length > 0)
                    labelQueryBuilder.Append(",");
                labelQueryBuilder.Append(dictEntry.Key);
                labelQueryBuilder.Append("=");
                labelQueryBuilder.Append(dictEntry.Value);
            }
            var pods = kubeClient.ListNamespacedPod(namespaceName, labelSelector: labelQueryBuilder.ToString());
            List<string> logAppendage = new List<string>();
            
            foreach(var pod in pods.Items)
            {
                using (var stream = await kubeClient.ReadNamespacedPodLogAsync(pod.Metadata.Name, namespaceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        logAppendage.Add(await reader.ReadToEndAsync());
                    }
                    stream.Flush();
                }
            }
            return Json(logAppendage);
        }
    }
}
