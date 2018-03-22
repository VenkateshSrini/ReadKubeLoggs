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

        // GET api/values/5
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
