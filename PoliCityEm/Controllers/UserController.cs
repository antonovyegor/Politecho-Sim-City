using PoliCityEm.BaseClass;
using PoliCityEm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PoliCityEm.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult GetAllUser()
        {
            IList<UserViewModel> users = null;

            using (var ctx = new PolitechContext())
            {
                users = ctx.users.Select(s => new UserViewModel()
                        {
                            UserId = s.UserId,
                            name = s.name
                           // city = s.city
                        }).ToList<UserViewModel>();

            }

            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }


        public IHttpActionResult GetUserById(int id)
        {
            UserViewModel user_ = null;

            using (var ctx = new PolitechContext())
            {
                user_ = ctx.users.Where(s => s.UserId == id)
                    .Select(s => new UserViewModel() {
                        UserId = s.UserId,
                        name = s.name,
                        city = s.city
                    }).FirstOrDefault<UserViewModel>();
            }

            if (user_ == null)
            {
                return NotFound();
            }

            return Ok(user_);
        }

        public IHttpActionResult GetUserByName(string name_)
        {
            UserViewModel user_ = null;

            using (var ctx = new PolitechContext())
            {
                user_ = ctx.users.Where(s => s.name.Equals(name_))
                    .Select(s => new UserViewModel()
                    {
                        UserId = s.UserId,
                        name = s.name,
                        city = s.city
                    }).FirstOrDefault<UserViewModel>();
            }

            if (user_ == null)
            {
                return NotFound();
            }

            return Ok(user_);
        }


        public IHttpActionResult PostNewStudent(UserViewModel user) /* TODO: DELETE
            так не пойдёт. Ты даёшь мне возможность создавать сколько угодно юзеров. Этот роут нужно убрать.
            Создать юзера можно только при регистрации. В методе регистрации будет валидация имейла пароля и всего прочего
        */
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new PolitechContext())
            {
                ctx.users.Add(new UserViewModel()
                {
                    UserId = user.UserId,
                    name = user.name,
                    password = user.password,
                    points = user.points,
                    city = new CityViewModel(user.UserId),
                    Friends = new List<int>()
                });

                //ctx.SaveChanges();

                //ctx.users.Add(new User()
                //{
                //    UserId = user.UserId,
                //    name = user.name,
                //    password = user.password,
                //    points = user.points,
                //    city = new City(user.UserId),
                //    Friends = new List<int>()
                //});

                //ctx.SaveChanges();
            }

            return Ok();
        }



        public IHttpActionResult PutUser(UserViewModel user) /* Так не делают. 
            Если нужно изменить пароль, то для этого делается отдельный метод. 
            А сейчас я из аппы смогу изменить количество денег или друзей. */
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new PolitechContext())
            {
                var existingUser = ctx.users.Where(s => s.UserId == user.UserId).FirstOrDefault<User>();

                if (existingUser != null)
                {
                    existingUser.name = user.name;
                    existingUser.points = user.points;
                    existingUser.UserId = user.UserId;
                    existingUser.password = user.password;
                    existingUser.Friends = user.Friends;

    
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }









    }
}
