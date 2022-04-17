using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryStore.Models
{
    public class AccountAdminEntity
    {
		[Required(ErrorMessage = "Username not null !")]
		[DisplayName("UserName")]
		public string userName { get; set; }

		[DisplayName("PassWord")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password not null !")]
		public string passWord { get; set; }
	}
}