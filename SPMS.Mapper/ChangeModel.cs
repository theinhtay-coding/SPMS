﻿using SPMS.Models.Grade;

namespace SPMS.Mapper;

public static class ChangeModel
{
    #region Students
    public static StudentModel Change(this Student student)
    {
        return new StudentModel
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            GradeId = student.GradeId,
            CurrentYearId = student.CurrentYearId,
            EnrollmentDate = student.EnrollmentDate
        };
    }

    public static StudentResponseModel ChangeToResponseModel(this Student student)
    {
        return new StudentResponseModel
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            GradeId = student.GradeId,
            CurrentYearId = student.CurrentYearId,
            EnrollmentDate = student.EnrollmentDate
        };
    }

    public static Student Change(this StudentRequestModel model)
    {
        return new Student
        {
            StudentId = model.StudentId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            GradeId = model.GradeId,
            CurrentYearId = model.CurrentYearId,
            EnrollmentDate = model.EnrollmentDate
        };
    }
    #endregion

    #region Grades
    public static GradeModel Change(this Grade model)
    {
        return new GradeModel
        {
            GradeId = model.GradeId,
            GradeName = model.GradeName,
            PaymentAmount = model.PaymentAmount
        };
    }

    public static GradeResponseModel ChangeToResponseModel(this Grade model)
    {
        return new GradeResponseModel
        {
            GradeId = model.GradeId,
            GradeName = model.GradeName,
            PaymentAmount = model.PaymentAmount
        };
    }
    #endregion
}
