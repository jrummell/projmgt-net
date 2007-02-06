using System;
using System.Collections.Generic;
using System.Text;
using PMT.DAL;

namespace PMT.BLL
{
    public class TaskData
    {
        public TaskData()
        {
            throw new System.NotImplementedException();
        }
    
        public ProjectsDataSet.TasksDataTable GetAssignedTasks()
        {
            throw new System.NotImplementedException();
        }

        public int InsertTask(Task task)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTask(Task task)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public ProjectsDataSet.TasksDataTable GetModuleTasks(int moduleID)
        {
            throw new System.NotImplementedException();
        }

        public bool AssignTask(int taskID, int devID)
        {
            throw new System.NotImplementedException();
        }

        public bool UnassignTask(int taskID, int devID)
        {
            throw new System.NotImplementedException();
        }

        public Task GetTask(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
