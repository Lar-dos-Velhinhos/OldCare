﻿using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.VerifyPhone.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.VerifyPhone;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<User?> GetUserByUsernameAsync(string username) 
        => await _context.Users.Where(x => x.Username.Address == username.ToLower()).FirstOrDefaultAsync();

    public async Task SaveAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}