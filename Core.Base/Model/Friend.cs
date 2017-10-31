using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Model
{
    public class Friend
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public virtual ICollection<Game> Games { get; set; }


        public bool IsValid
        {
            get { return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true); }
        }

        public bool Update(Friend friend)
        {
            if (this.Id == friend.Id)
            {
                this.Name = friend.Name;
                this.City = friend.City;
                this.Address = friend.Address;

                return true;
            }
            return false;
        }
    }
}
