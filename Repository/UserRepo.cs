using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsApi.Models;

namespace UserDetailsApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly SpotifyDemoDbContext _context;

        public UserRepo(SpotifyDemoDbContext context)
        {
            _context = context;
        }

 

        public IEnumerable<UserDetails> GetUserDetails()
        {
            return _context.UserDetails.ToList();   
        }

        public UserDetails GetUserDetailsById(int id)
        {
            UserDetails userdata = _context.UserDetails.Find(id);
            return userdata;
        }

        public async Task<UserDetails> PostUser(UserDetails user)
        {
            UserDetails userdata = null;
            if (user == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                userdata = new UserDetails() {Username = user.Username, Useremail = user.Useremail, Phonenumber = user.Phonenumber, Password = user.Password, Dob = user.Dob, Role = "User"};

                await _context.UserDetails.AddAsync(userdata);
                await _context.SaveChangesAsync();

            }
            return userdata;

        }

        public async Task<UserDetails> UpdateUser(int id, UserDetails user)
        {
            UserDetails userdata = await _context.UserDetails.FindAsync(id);
            userdata.Username = user.Username;
            userdata.Phonenumber = user.Phonenumber;
            userdata.Dob = user.Dob;

            await _context.SaveChangesAsync();

            return userdata;

        }

        
    }
}
