using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://localhost:7136"; // Thay đổi theo địa chỉ API của bạn

        using (var httpClient = new HttpClient())
        {
            // GET Users
            var users = await httpClient.GetFromJsonAsync<List<User>>($"{apiUrl}/api/users");
            Console.WriteLine("Users:");
            PrintUsers(users);

            // POST User
            var newUser = new User { FullName = "New User", Email = "newuser@example.com" };
            var createdUser = await httpClient.PostAsJsonAsync($"{apiUrl}/api/users", newUser).Result.Content.ReadFromJsonAsync<User>();
            Console.WriteLine("\nUser Created:");
            PrintUser(createdUser);

            // PUT User
            var updateUser = new User { UserId = createdUser.UserId, FullName = "Updated User", Email = "updateduser@example.com" };
            await httpClient.PutAsJsonAsync($"{apiUrl}/api/users/{updateUser.UserId}", updateUser);

            // GET Updated Users
            var updatedUsers = await httpClient.GetFromJsonAsync<List<User>>($"{apiUrl}/api/users");
            Console.WriteLine("\nUpdated Users:");
            PrintUsers(updatedUsers);

            // DELETE User
            await httpClient.DeleteAsync($"{apiUrl}/api/users/{updateUser.UserId}");

            // GET Users after DELETE
            var usersAfterDelete = await httpClient.GetFromJsonAsync<List<User>>($"{apiUrl}/api/users");
            Console.WriteLine("\nUsers after DELETE:");
            PrintUsers(usersAfterDelete);
        }
    }

    static void PrintUsers(List<User> users)
    {
        foreach (var user in users)
        {
            PrintUser(user);
        }
    }

    static void PrintUser(User user)
    {
        Console.WriteLine($"User ID: {user.UserId}, Full Name: {user.FullName}, Email: {user.Email}");
    }
}

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}
