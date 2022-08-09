﻿using OldCare.Contexts.AccountContext.Entities;
using OldCare.Contexts.AccountContext.UseCases.ResendEmailVerificationCode.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data.Contexts.AccountContext.UseCases.ResendEmailVerificationCode;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<bool> CheckAccountIsBlackListedAsync(string username)
        => await _context.BlackLists.AnyAsync(x => x.Email.Address == username.ToLower());

    public async Task<User?> GetUserByUsernameAsync(string username)
        => await _context.Users
            .Include(x => x.Person)
            .Where(x => x.Username.Address == username.ToLower())
            .FirstOrDefaultAsync();

    public async Task SaveAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}