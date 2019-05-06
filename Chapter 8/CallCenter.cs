using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.2
    class CallCenter
    {
        ArrayList respondents, managers, directors;

        public CallCenter()
        {
            respondents = new ArrayList();
            managers = new ArrayList();
            directors = new ArrayList();
        }

        public void AddEmployee(string type, string name)
        {
            switch (type.ToUpper())
            {
                case "RESPONDENT":
                    respondents.Add(new Respondent(name));
                    break;
                case "MANAGER":
                    managers.Add(new Manager(name));
                    break;
                case "DIRECTOR":
                    directors.Add(new Director(name));
                    break;
            }
        }

        public void DispatchCall(Call c)
        {
            for (int i = 0; i < respondents.Count; i++)
            {
                Respondent respondent = (Respondent)respondents[i];
                if (!respondent.IsBusy())
                {
                    respondent.TakeCall(c);
                    Console.WriteLine(respondent.GetName());
                    return;
                }
            }
        }

        public void EscalateCall(Employee emp)
        {
            if (emp.GetEmployeeType().ToUpper() == "RESPONDENT")
            {
                // Escalate to manager
                for (int i = 0; i < managers.Count; i++)
                {
                    Manager manager = (Manager)managers[i];
                    if (!manager.IsBusy())
                    {
                        manager.TakeCall(emp.GetCall());
                        emp.EndCall();
                        return;
                    }
                }
            }

            if (emp.GetEmployeeType().ToUpper() == "RESPONDENT" || emp.GetEmployeeType().ToUpper() == "MANAGER")
            {
                // Escalate to director
                for (int i = 0; i < directors.Count; i++)
                {
                    Director director = (Director)directors[i];
                    if (!director.IsBusy())
                    {
                        director.TakeCall(emp.GetCall());
                        emp.EndCall();
                        return;
                    }
                }
            }
        }

        public static void RunCallCenter()
        {
            // Create call center
            CallCenter callCenter = new CallCenter();

            // Add Employees
            callCenter.AddEmployee("respondent", "Jessica");
            callCenter.AddEmployee("respondent", "Sam");
            callCenter.AddEmployee("respondent", "Jake");
            callCenter.AddEmployee("respondent", "Luke");
            callCenter.AddEmployee("manager", "Liz");
            callCenter.AddEmployee("manager", "Tammy");
            callCenter.AddEmployee("director", "Tyler");

            Call call = new Call("Help me please.");

            callCenter.DispatchCall(call);
        }
    }

    public class Call
    {
        string msg;

        public Call(string m)
        {
            msg = m;
        }
    }

    public class Employee
    {
        string name, type;
        Call call;
        bool busy;

        public Employee(string n)
        {
            name = n;
            call = null;
            busy = false;
        }

        public bool IsBusy()
        {
            return busy;
        }

        public void TakeCall(Call c)
        {
            call = c;
            busy = true;
        }

        public void EndCall()
        {
            call = null;
            busy = false;
        }

        public Call GetCall()
        {
            return call;
        }

        public string GetEmployeeType()
        {
            return type;
        }

        public string GetName()
        {
            return name;
        }

        public void SetEmployeeType(string t)
        {
            type = t;
        }
    }

    class Respondent : Employee
    {
        public Respondent(string n) : base(n)
        {
            base.SetEmployeeType("Respondent");
        }
    }

    class Manager : Employee
    {
        public Manager(string n) : base(n)
        {
            base.SetEmployeeType("Manager");
        }
    }

    class Director : Employee
    {
        public Director(string n) : base(n)
        {
            base.SetEmployeeType("Director");
        }
    }
}
