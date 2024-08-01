using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ImdbClone.Persistence.Repositories;

public class UserRepository: GenericRepository<ApplicationUser>, IUserRepository
{
    private readonly FilmDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public UserRepository(FilmDbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task AddWatchedFilm(ApplicationUser user, Film film)
    {
        var userToModify = await _dbContext.Users.FindAsync(user.Id);
        var watchedFilm = await _dbContext.Films.FindAsync(film.Id);
        userToModify.WatchedFilms.Add(watchedFilm);
        _dbContext.Entry(userToModify).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }

    public async Task<ApplicationUser> FindUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == email);
        
    }

    public string GenerateToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Username!)
        };
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}