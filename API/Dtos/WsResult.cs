namespace API.Dtos
{
    public class WsResult
    {
        public int result { get; set; }
        public string message { get; set; }

        public WsResult()
        {
            this.result = -1;
            this.message = "[ UNDEFINED ]";
        }

        public void SetResultOk()
        {
            this.result = 0;
            this.message = "Ok";
        }
        public void SetResult(int result, string message)
        {
            this.result = result;
            this.message = message;
        }

    }
}
