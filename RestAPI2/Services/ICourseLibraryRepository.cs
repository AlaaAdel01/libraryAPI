﻿using CourseLibrary.API.Entities;
using RestAPI2.Helper;
using RestAPI2.ResourceParametres;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Services
{
    public interface ICourseLibraryRepository
    {    
        IEnumerable<Course> GetCourses(Guid authorId);
        Course GetCourse(Guid authorId, Guid courseId);
        void AddCourse(Guid authorId, Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        IEnumerable<Author> GetAuthors();

        PageList<Author> GetAuthors(AuthorsResourceParametres para);
        Author GetAuthor(Guid authorId);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
        bool Save();
    }
}
