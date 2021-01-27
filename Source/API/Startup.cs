using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddControllers();

			services.AddAuthentication(options =>
					{
						options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.SaveToken = true;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(Settings.Key),
							ValidateIssuer = false,
							ValidateAudience = false
						};
					});
		}

		public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				application.UseDeveloperExceptionPage();
			}
			application.UseHttpsRedirection();
			application.UseRouting();

			application.UseCors(options => options
								.AllowAnyOrigin()
								.AllowAnyMethod()
								.AllowAnyHeader());								

			application.UseAuthentication();
			application.UseAuthorization();

			application.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
