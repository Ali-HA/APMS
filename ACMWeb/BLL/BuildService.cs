using CyberWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberWeb.BLL
{
    public class BuildService
    {
        public static void BuildSystem(int BuildId)
        {
            using (var db = new ApplicationDbContext())
            {
                var build = db.Builds.Find(BuildId);
                
                //here will be the matlab function call
                //func_build(DataFileName, BuildFileName, TrainingSetSize, TrainingSetGenMethod, CombinerType, FusionMethod, FusedNo, Perc, ClassifierType, k, MidLayerSize, TrainGoal, RepocsNo, Ltf1, Ltf2, Ltf3, TrainFunc, RBFSigma, BoxConstrains) 
            }
        }

        public static void EvalSystem(int EvaluateID)
        {
            using (var db = new ApplicationDbContext())
            {
                var evaluate = db.Evaluates.Find(EvaluateID);

                //here will be the matlab function call
                //evaluate.PerfRate =  func_Eval( NoOfRep, DataFileName, BuildFileName, TrainingSetSize, TrainingSetGenMethod, CombinerType, FusionMethod, FusedNo, Perc, ClassifierType, k, MidLayerSize, TrainGoal, RepocsNo, Ltf1, Ltf2, Ltf3, TrainFunc, RBFSigma, BoxConstrains) 
                //db.SaveChanges();
            }
        }

    }
}