// This file is generated, don't touch
using Calculator.Models;
using Calculator.Models.RequestResponse;
using System.Collections.Generic;


namespace Calculator.Models.ViewModels
{
    public partial class ActiveWebPageDataVM {
        public ActiveWebPageDataVM()
        {
            WebContentsVM = new HashSet<WebContentVM>();
        }

        public virtual WebPageVM WebPageVM { get; set; }
        public virtual ICollection<WebContentVM> WebContentsVM { get; set; }
    }
}