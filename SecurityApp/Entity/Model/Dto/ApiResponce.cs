using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto
{
    public class ApiResponce<T>
    {
        private T data { get; set; }
        private string menssage{ get; set; }
        private Boolean status { get; set; }
        public ApiResponce(T data, string menssage, Boolean status) { 
            this.data = data;
            this.menssage = menssage;
            this.status = status;
        }

    }
}
