namespace HD_Veriler.DTO
{
    public class DTOScore
    {

        public int ScoreID { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public string? Answer { get; set; }     
        public int Point { get; set; }
        public DateTime AnswerDate { get; set; }

    }

}
