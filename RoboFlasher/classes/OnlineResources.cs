using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoboFlasher.classes {
    public class OnlineResources {

        public List<Firmware> firmwares { get; set; }
        public List<Repo> voicepacks { get; set; }
        public List<Repo> webinterface { get; set; }
        public class Firmware {
            public List<Repo> originalimages { get; set; }
            public List<Repo> customimages { get; set; }
        }

        public class Repo {
            public string version { get; set; }
            public string url { get; set; }
            public string xiaomidevice { get; set; }
            public string user { get; set; }
            public string repository { get; set; }
            public List<object> download { get; set; }
            public List<object> preinstall { get; set; }
            public string install { get; set; }
            public string description { get; set; }
            public List<Release> releases { get; private set; }
            public async Task getReleases() {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(repository))
                    return;
                string download;
                download = "https://api.github.com/repos/" + user + "/" + repository + "/releases";

                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("RoborockFlasher", "1.0"));
                    HttpResponseMessage response = await httpClient.GetAsync(download);
                    string res = await response.Content.ReadAsStringAsync();
                    releases = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Release>>(res);
                }
            }
            public class Release {
                public class Asset {
                    public string url { get; set; }
                    public int id { get; set; }
                    public string node_id { get; set; }
                    public string name { get; set; }
                    public object label { get; set; }
                    public string content_type { get; set; }
                    public string state { get; set; }
                    public int size { get; set; }
                    public int download_count { get; set; }
                    public DateTime created_at { get; set; }
                    public DateTime updated_at { get; set; }
                    public string browser_download_url { get; set; }
                }
                public string url { get; set; }
                public string assets_url { get; set; }
                public string upload_url { get; set; }
                public string html_url { get; set; }
                public int id { get; set; }
                public string node_id { get; set; }
                public string tag_name { get; set; }
                public string target_commitish { get; set; }
                public string name { get; set; }
                public bool draft { get; set; }
                public bool prerelease { get; set; }
                public DateTime created_at { get; set; }
                public DateTime published_at { get; set; }
                public List<Asset> assets { get; set; }
                public string tarball_url { get; set; }
                public string zipball_url { get; set; }
                public string body { get; set; }
            }
            public async void downloadRelease(string folder, Release rel) {
                string download;
                download = "https://api.github.com/repos/" + user + "/" + repository + "/releases";
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("RoborockFlasher", "1.0"));
                    HttpResponseMessage response = await httpClient.GetAsync(download);
                    Stream res = await response.Content.ReadAsStreamAsync();
                    using (var fs = new FileStream(folder, FileMode.OpenOrCreate)) {
                        await res.CopyToAsync(fs);
                    }
                }
            }
        }
    }
}
