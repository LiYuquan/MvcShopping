using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcShopping.ViewModel
{
    public class MemberLoginViewModel
    {

        [Required(ErrorMessage="请输入{0}")]
        [DataType(DataType.EmailAddress,ErrorMessage="请输入您的Email地址")]
        [DisplayName("会员账号")]
        public string email { get; set; }


        [Required(ErrorMessage="请输入{0}")]
        [DisplayName("会员密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}