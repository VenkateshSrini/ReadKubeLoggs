using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadKubeLogs.Service.config
{

    public class KubernetesClusterConfigData
    {
        public string Host { get; set; }
        public bool SkipSSLVerify { get; set; }
        public string ClientCertificateData { get; set; }
        public string ClientCertificateKeyData { get; set; }
        public string AccessToken { get; set; }
    }

}
