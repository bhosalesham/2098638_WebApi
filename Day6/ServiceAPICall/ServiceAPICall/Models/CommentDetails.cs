namespace ServiceAPICall.Models
{
    public class CommentDetails
    {
        public int PostId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string body { get; set; }

        List<CommentDetails> cList = new List<CommentDetails>();

        public List<CommentDetails> GetComments()
        {
            string url = "https://jsonplaceholder.typicode.com/comments";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear(); //clear all the default client setting and we will set json for call
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url).Result;

            if (call.IsSuccessStatusCode) //if we are getting success codes - 200 to 299 seriees, we will read data, else exception
            {
                var data = call.Content.ReadAsAsync<List<CommentDetails>>();
                data.Wait();
                cList = data.Result;
                return cList;
            }
            else
            {
                throw new Exception("Sorry Could not get data, pleaes contact Admin");
            }
        }
    }
}
