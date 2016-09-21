using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Abstractions;

namespace ShunghamUtilities
{
    public static class FormsUtilities
    {
        public static void SubmitForm(string firstName, string lastName, string email, string phone, string company, string message, string ipAddress, Guid userId, string formName)
        {
            Dictionary<string, string> inputs = new Dictionary<string, string>();

            inputs.Add("FirstName", firstName);
            inputs.Add("LastName", lastName);
            inputs.Add("Email", email);
            inputs.Add("PhoneNumber", phone);
            inputs.Add("Company", company);
            inputs.Add("Message", message);

            FormsManager manager = FormsManager.GetManager();
            var form = manager.GetFormByName(formName);
            FormEntry entry = manager.CreateFormEntry(form.EntriesTypeName);

            foreach (var item in inputs)
            {
                entry.SetValue(item.Key, item.Value);
            }

            entry.IpAddress = ipAddress;
            entry.UserId = userId;

            if (AppSettings.CurrentSettings.Multilingual)
            {
                entry.Language = System.Globalization.CultureInfo.CurrentUICulture.Name;
            }

            entry.ReferralCode = (manager.Provider.GetNextReferralCode(entry.GetType().ToString())).ToString();
            entry.SubmittedOn = System.DateTime.UtcNow;

            manager.SaveChanges();
        }
    }
}
