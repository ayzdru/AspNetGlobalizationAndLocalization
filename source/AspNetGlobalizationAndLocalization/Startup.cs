using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using AspNetGlobalizationAndLocalization.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;
using Xaki.AspNetCore.Configuration;

namespace AspNetGlobalizationAndLocalization
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddErrorDescriber<MultilanguageIdentityErrorDescriber>();
           
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("tr"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "tr", uiCulture: "tr");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                {
                    // My custom request culture logic
                    return new ProviderCultureResult("en");
                }));
            });
            services.AddMvc(o =>
            {
                var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var localizer = factory.Create(nameof(ModelBindingMessages), typeof(ModelBindingMessages).GetTypeInfo().Assembly.GetName().Name);

                o.ModelBindingMessageProvider
                    .SetAttemptedValueIsInvalidAccessor((x, y) => localizer[ModelBindingMessages.ModelState_AttemptedValueIsInvalid, x, y]);
                o.ModelBindingMessageProvider
                    .SetMissingBindRequiredValueAccessor((x) => localizer[ModelBindingMessages.ModelBinding_MissingBindRequiredMember, x]);
                o.ModelBindingMessageProvider
                    .SetMissingKeyOrValueAccessor(() => localizer[ModelBindingMessages.KeyValuePair_BothKeyAndValueMustBePresent]);
                o.ModelBindingMessageProvider
                    .SetMissingRequestBodyRequiredValueAccessor(() => localizer[ModelBindingMessages.ModelBinding_MissingRequestBodyRequiredMember]);
                o.ModelBindingMessageProvider
                    .SetNonPropertyAttemptedValueIsInvalidAccessor((x) => localizer[ModelBindingMessages.ModelState_NonPropertyAttemptedValueIsInvalid, x]);
                o.ModelBindingMessageProvider
                    .SetNonPropertyUnknownValueIsInvalidAccessor(() => localizer[ModelBindingMessages.ModelState_NonPropertyUnknownValueIsInvalid]);
                o.ModelBindingMessageProvider
                    .SetNonPropertyValueMustBeANumberAccessor(() => localizer[ModelBindingMessages.HtmlGeneration_NonPropertyValueMustBeNumber]);
                o.ModelBindingMessageProvider
                    .SetUnknownValueIsInvalidAccessor((x) => localizer[ModelBindingMessages.ModelState_UnknownValueIsInvalid, x]);
                o.ModelBindingMessageProvider
                    .SetValueIsInvalidAccessor((x) => localizer[ModelBindingMessages.HtmlGeneration_ValueIsInvalid, x]);
                o.ModelBindingMessageProvider
                    .SetValueMustBeANumberAccessor((x) => localizer[ModelBindingMessages.HtmlGeneration_ValueMustBeNumber, x]);
                o.ModelBindingMessageProvider
                    .SetValueMustNotBeNullAccessor((x) => localizer[ModelBindingMessages.ModelBinding_NullValueNotValid, x]);
            })
              .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
              .AddDataAnnotationsLocalization(options => {
                  options.DataAnnotationLocalizerProvider = (type, factory) =>
                      factory.Create(typeof(DataAnnotationMessages));
              }).AddXaki(new XakiOptions
              {
                  RequiredLanguages = new[] { "tr"},
                  OptionalLanguages = new[] { "en" }
              });
            services.AddSingleton<EFStringLocalizerFactory>(option =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            return new EFStringLocalizerFactory(new ApplicationDbContext(optionsBuilder.Options));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseXaki();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new[] { "tr", "en" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
