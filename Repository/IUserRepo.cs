using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsApi.Models;

namespace UserDetailsApi.Repository
{
    public interface IUserRepo
    {

        IEnumerable<UserDetails> GetUserDetails();

        UserDetails GetUserDetailsById(int id);

        Task<UserDetails> UpdateUser( int id, UserDetails user);

        Task<UserDetails> PostUser(UserDetails user);


    }
}
