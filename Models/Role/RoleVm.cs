using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models.User
{
    public class RoleVm
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}