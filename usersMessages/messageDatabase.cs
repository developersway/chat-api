namespace dot_net.userMessages
{
    public class MessageDatabase{
        public static  List<userMessagesList> msgList = new List<userMessagesList>();

        public static void addMessagesToServer(userMessagesList data)
        {
            msgList.Add(data);
        }
    }
}