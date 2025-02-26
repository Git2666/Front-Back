// using AutoMapper;
// using Backend.Blog.Model;
// using Backend.Blog.Model.DTO;
// using Backend.IBaseService;
// using Backend.Util;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
//
// namespace Backend.Blog.Controller;
//
// [Route("api/[controller]")]
// [ApiController]
// public class UserController : ControllerBase
// {
//     private readonly IMapper _mapper;
//     private readonly UserManager<User> _userManager;
//     private readonly RoleManager<Role> _roleManager;
//
//     public UserController(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
//     {
//         _mapper = mapper;
//         _userManager = userManager;
//         _roleManager = roleManager;
//     }
//     
//     [HttpGet("GetUsers")]
//     public async Task<ActionResult<ApiResult>> GetUsers()
//     {
//         var data = await _userManager.Users.ToListAsync();
//
//         if (data.Count == 0)
//         {
//             return ApiResultHelper.Error($"没有更多的用户了!");
//         }
//
//         List<UserDTO> users = new List<UserDTO>();
//
//         foreach (var user in data)
//         {
//             users.Add(_mapper.Map<UserDTO>(user));
//         }
//
//         return ApiResultHelper.Success(users);
//     }
//     
//     [HttpPost("CreateUser")]
//     public async Task<ActionResult<ApiResult>> CreateUser(string name, string pwd)
//     {
//         User user = new User() { UserName = name, IsDeleted = false };
//         var b = await _userManager.CreateAsync(user, pwd);
//         if (!b.Succeeded)
//         {
//             return ApiResultHelper.Error($"创建用户失败");
//         }
//
//         //添加角色
//         if (await _userManager.IsInRoleAsync(user, "Normal"))
//         {
//             await _userManager.AddToRoleAsync(user, "Normal");
//         }
//
//         return ApiResultHelper.Success(b.Succeeded);
//     }
// }