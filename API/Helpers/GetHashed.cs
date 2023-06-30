using System.Text;

namespace API.Helpers
{
    public class GetHashed
    {
        public string GetHashedKey(string instanceId, string referenceId, string accessKey)
        {
            if (instanceId == null || referenceId == null || accessKey == null) return "";

            instanceId = instanceId.Trim();
            referenceId = referenceId.Trim();
            accessKey = accessKey.Trim();
            if (instanceId == "" || referenceId == "" || accessKey == "") return "";

            string text = instanceId + "|" + referenceId + "/" + accessKey + "!";

            using (var sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
    }
}
