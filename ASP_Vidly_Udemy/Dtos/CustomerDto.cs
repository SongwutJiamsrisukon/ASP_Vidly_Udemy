using ASP_Vidly_Udemy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //In DTO class, all property must using inside View like Form, textLabel, img and etc {ให้นึกถึงข้อมูลที่จะนำมาใช้ไม่ว่าส่งไปหรือรับกลับระหว่างSVและClient}
        //public MembershipType MembershipType { get; set; }//No need in my design but if in the future  you need this you must create MemberShipTypeDto Class
        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }//foreignkey auto generate by entityFramework

        public DateTime? BirthDate { get; set; }
    }
}