using NewsProject.ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsProject.ClientWPF
{
    public class SimpleNews : BaseModel
    {
       
            public string title { get; set; }
            public DateTime dateOfPublication { get; set; }
            public int? likesCount { get; set; }
      


    }
}
