using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflowProject.DomainModels;


namespace StackOverflowProject.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepository: IVotesRepository
    {
        StackOverflowDbContext db;
        public VotesRepository()
        {
            db = new StackOverflowDbContext();
        }

        public void UpdateVote(int aid, int uid, int value)
        {
            int updatevalue;
            if (value > 0) updatevalue = 1;
            else if (value < 0) updatevalue = -1;
            else updatevalue = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == aid && temp.UserID == uid).FirstOrDefault();
            if(vote!=null)
            {
                vote.VoteValue = updatevalue;
            }
            else
            {
                Vote newVote = new Vote() { AnswerID = aid, UserID = uid, VoteValue = updatevalue };
                db.Votes.Add(newVote);
            }
            db.SaveChanges();
        }
    }
}
