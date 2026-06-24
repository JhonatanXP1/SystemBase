using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class EndpointAccessSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<endpointAccess>().HasData(
            new
            {
                id = 1,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.*",
                status = true
            },
            new
            {
                id = 2,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.subordinate",
                status = true
            },
            new
            {
                id = 3,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.*",
                status = true
            }
            ,
            new
            {
                id = 4,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.subordinate",
                status = true
            },
            new
            {
                id = 5,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.self",
                status = true
            },
            new
            {
                id = 6,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.*",
                status = true
            },
            new
            {
                id = 7,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.subordinate",
                status = true
            },
            new
            {
                id = 8,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.self",
                status = true
            },
            new
            {
                id = 9,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.subordinate",
                status = true
            },
            new
            {
                id = 10,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.*",
                status = true
            },
            new
            {
                id = 11,
                endpoint = "/user",
                method = "POST",
                permission = "users.create.*",
                status = true
            },
            new
            {
                id = 12,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.self",
                status = true
            },
            new
            {
                id = 13,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.subordinate",
                status = true
            },
            new
            {
                id = 14,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.*",
                status = true
            },
            new
            {
                id = 15,
                endpoint = "/user/{id}",
                method = "DELETE",
                permission = "users.delete.*",
                status = true
            },
            new
            {
                id = 16,
                endpoint = "/user/{id}/status",
                method = "PATCH",
                permission = "users.status.*",
                status = true
            },
            new
            {
                id = 17,
                endpoint = "/user/{id}/assignment",
                method = "POST",
                permission = "users.assignment.create.*",
                status = true
            },
            new
            {
                id = 18,
                endpoint = "/user/{id}/assignment/{assignmentId}",
                method = "DELETE",
                permission = "users.assignment.delete.*",
                status = true
            },
            new
            {
                id = 19,
                endpoint = "/user/{id}/password",
                method = "PUT",
                permission = "users.password.self",
                status = true
            },
            new
            {
                id = 20,
                endpoint = "/user/{id}/password",
                method = "PUT",
                permission = "users.password.*",
                status = true
            },
            new
            {
                id = 21,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.self",
                status = true
            },
            new
            {
                id = 22,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.subordinate",
                status = true
            },
            new
            {
                id = 23,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.*",
                status = true
            },
            new
            {
                id = 24,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.self",
                status = true
            },
            new
            {
                id = 25,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.self",
                status = true
            }
        );
    }
}