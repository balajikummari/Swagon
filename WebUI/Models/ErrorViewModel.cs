using System;

namespace WebUI.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
     
    public class User
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}
