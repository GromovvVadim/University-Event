using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University_Event.WebUI.Form
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "Не вказано логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
