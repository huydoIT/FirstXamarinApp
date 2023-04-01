using FirstXamarinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

namespace FirstXamarinApp.Ultil
{
    public class FirebaseHelper
    {

        FirebaseClient firebase = new FirebaseClient("https://theusers-233fb.firebaseio.com/");
        public async Task<List<Account>> GetAllPersons()
        {
            return (await firebase
              .Child("User")
              .OnceAsync<Account>()).Select(item => new Account
              {
                  FullName = item.Object.FullName,
                  Gender = item.Object.Gender,
                  Username = item.Object.Username,
                  Password = item.Object.Password,
              }).ToList();
        }

        public async Task<Account> GetPerson(string userName)
        {
            /*
            var allPersons = await GetAllPersons();
            await firebase
              .Child("User")
              .OnceAsync<Account>();
            return allPersons.Where(a => a.Username == userName).FirstOrDefault();
            */

            return (await firebase
              .Child("User")
              .OnceAsync<Account>()).Where(a => a.Key == userName).Select(item => new Account
              {
                  FullName = item.Object.FullName,
                  Gender = item.Object.Gender,
                  Username = item.Object.Username,
                  Password = item.Object.Password,
              }).FirstOrDefault();
        }
    }
}
