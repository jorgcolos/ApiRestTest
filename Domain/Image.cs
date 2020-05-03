using System.Collections.Generic;

namespace Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string IdCloudinary { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}