using DevFreela.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services;

public interface IUserService
{ 
    ResultViewModel<List<UserViewModel>> GetAll(string search = "");
    ResultViewModel<int> Insert(CreateUserInputModel model);
    
    ResultViewModel<UserViewModel> GetById(int id);
    
    ResultViewModel Delete(int id);
    
}