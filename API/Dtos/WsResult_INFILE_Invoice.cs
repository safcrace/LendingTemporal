namespace API.Dtos
{
    public class WsResult_INFILE_Invoice : WsResult
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
        public Dictionary<string, string> errorMessages = new Dictionary<string, string>();

        public void AddDataLine(string key, string text) { data.Add(key, text); }

        public void AddErrorMessage(string text) { errorMessages.Add((errorMessages.Count + 1).ToString(), text); }

    }
}
