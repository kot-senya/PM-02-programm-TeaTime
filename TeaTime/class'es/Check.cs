using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTime
{
    public class Checks
    {
        public static bool checkWorker(string login, string password, out Worker worker)
        {
            bool check = false;
            worker = new Worker();
            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                List<Worker> w = DB.Worker.ToList();
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].login == login && w[i].password == password)
                    {
                        check = true;
                        worker = w[i];
                    }
                }
            }
            return check;
        }
        public static bool checkMember(string login, string password, out Member member)
        {
            bool check = false;
            member = new Member();
            using (KotkovaISazonovaEntities_ DB = new KotkovaISazonovaEntities_())
            {
                List<Member> m = DB.Member.ToList();
                for (int i = 0; i < m.Count; i++)
                {
                    if (m[i].login == login && m[i].password == password)
                    {
                        check = true;
                        member = m[i];
                    }
                }
            }
            return check;
        }
    }
    
}
