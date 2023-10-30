using Microsoft.AspNetCore.Components.Forms;
using ThinkLogic.Common.Models;

namespace ThinkLogic.UI.Pages
{
    public partial class Index
    {
        public DateTime CurrentDate { get; set; }

        public Filter PageFilter { get; set; } = new Filter();



        


        
        
        
        
        public class Filter
        {
            public DateTime Date { get; set; }
        }
    }


}