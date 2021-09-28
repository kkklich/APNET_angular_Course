using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context=context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.User.ToListAsync();
        }

        
        /// api/users/5
        [HttpGet("details")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {            
            return await context.User.FindAsync(id);
        }

        [HttpGet("detailsName")]
        public ActionResult<IEnumerable<AppUser>> GetUserName(string userName)
        {
            var user=context.User.Where(x=> x.UserName==userName).ToList();
            return  user;
        }




        public string GenerateRandomString()
        {
            string alphabet="a ą b c ć d e ę f g h i j k l ł m n ń o ó p r s ś t u w y z ź ż A Ą B C Ć D E Ę F G H I J K L Ł M N Ń O Ó P R S Ś T U W Y Z Ź Ż 123456789";
            string randomString="";
            string NoWhiteString=alphabet;
            Random rand=new Random();
            int quantityNr= rand.Next(5,15);
            for(int i=0;i<quantityNr;i++)
            {
                int randNr=rand.Next(0,NoWhiteString.Length);
                char sign=NoWhiteString[randNr];
                randomString+=sign;
            }

            return randomString;

        }

    }
}