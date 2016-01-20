using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class RoleViewModel
    {
        public string OriginalRoleName { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
            this.Description = role.Description;
        }
    }
}