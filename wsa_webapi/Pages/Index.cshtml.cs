using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wsa_webapi.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> ImageUrls { get; set; }
        public void OnGet()
        {

        }
    }
}
