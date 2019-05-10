using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.7
    class ChatServer
    {
        ArrayList registeredUsers;
        ArrayList onlineUsers;

        public ChatServer()
        {
            registeredUsers = new ArrayList();
            onlineUsers = new ArrayList();
        }

        public void RegisterUser(string username, string pass)
        {
            registeredUsers.Add(new ChatUser(username, pass));
        }

        public bool DeleteUser(ChatUser u)
        {
            if (!u.Online)
            {
                registeredUsers.Remove(u);
                return true;
            }
            else
                return false;
        }

        public bool Login(string username, string pass)
        {
            foreach (ChatUser cu in registeredUsers)
            {
                if (cu.GetUsername() == username)
                {
                    if (cu.AuthenticatePass(pass))
                    {
                        onlineUsers.Add(cu);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Logoff(string username)
        {
            foreach (ChatUser cu in onlineUsers)
            {
                if (cu.GetUsername() == username)
                {
                    onlineUsers.Remove(cu);
                    return true;
                }
            }
            return false;
        }

        public static void RunChatServer()
        {

        }
    }

    class ChatUser
    {
        string username, password;
        ArrayList friends;
        public bool Online { get; set; }
        public string Status { get; set; }

        public ChatUser(string un, string pass)
        {
            username = un;
            password = pass;
            friends = new ArrayList();
        }

        public void AddFriend(ChatUser cu)
        {
            friends.Add(cu);
        }

        public bool RemoveFriend(ChatUser cu)
        {
            if (friends.Contains(cu))
            {
                friends.Remove(cu);
                return true;
            }
            else
                return false;
        }

        public string GetUsername()
        {
            return username;
        }

        public bool AuthenticatePass(string pass)
        {
            if (password == pass)
                return true;
            else
                return false;
        }
    }

    abstract class Chat
    {

    }

    class PrivateChat : Chat
    {

    }

    class GroupChat : Chat
    {

    }
}
