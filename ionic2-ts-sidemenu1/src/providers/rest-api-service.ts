import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

/*
  Generated class for the RestAPISErvice provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class RestAPIService {

    apiUrl = 'http://localhost:64110/api';


    constructor(public http: Http) {
      console.log('Hello RestAPIService Provider');
    }

    
      
      
      
      
      
    public letterGrades: any[];
    getLetterGrades() {

        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/LetterGrades?expand=all')
                .map(res => res.json())
                .subscribe(data => {
                    this.letterGrades = data;
                    resolve(this.letterGrades);
                });
        });
    }

    public letterGrade: any[];
    getLetterGrade(letterGrade: any) {
        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/LetterGrades?expand=all&letterGradeId=' + letterGrade.LetterGradeId)
                .map(res => res.json())
                .subscribe(data => {
                    this.letterGrade = data;
                    resolve(this.letterGrade);
                });
        });
    }

    
    updateLetterGrade(letterGrade: any) {
         return new Promise(resolve => {
            this.http.put(this.apiUrl + '/LetterGrades', letterGrade)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    addNewLetterGrade(letterGrade: any) {
         return new Promise(resolve => {
            this.http.post(this.apiUrl + '/LetterGrades', letterGrade)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }

    deleteLetterGrade(letterGrade: any) {
         return new Promise(resolve => {
            this.http.delete(this.apiUrl + '/LetterGrades?letterGradeId=' + letterGrade.LetterGradeId)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    
      
      
      
      
      
    public assignments: any[];
    getAssignments() {

        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/Assignments?expand=all')
                .map(res => res.json())
                .subscribe(data => {
                    this.assignments = data;
                    resolve(this.assignments);
                });
        });
    }

    public assignment: any[];
    getAssignment(assignment: any) {
        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/Assignments?expand=all&assignmentId=' + assignment.AssignmentId)
                .map(res => res.json())
                .subscribe(data => {
                    this.assignment = data;
                    resolve(this.assignment);
                });
        });
    }

    
    updateAssignment(assignment: any) {
         return new Promise(resolve => {
            this.http.put(this.apiUrl + '/Assignments', assignment)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    addNewAssignment(assignment: any) {
         return new Promise(resolve => {
            this.http.post(this.apiUrl + '/Assignments', assignment)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }

    deleteAssignment(assignment: any) {
         return new Promise(resolve => {
            this.http.delete(this.apiUrl + '/Assignments?assignmentId=' + assignment.AssignmentId)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    
      
      
      
      
      
    public courses: any[];
    getCourses() {

        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/Courses?expand=all')
                .map(res => res.json())
                .subscribe(data => {
                    this.courses = data;
                    resolve(this.courses);
                });
        });
    }

    public course: any[];
    getCourse(course: any) {
        return new Promise(resolve => {
            this.http.get(this.apiUrl + '/Courses?expand=all&courseId=' + course.CourseId)
                .map(res => res.json())
                .subscribe(data => {
                    this.course = data;
                    resolve(this.course);
                });
        });
    }

    
    updateCourse(course: any) {
         return new Promise(resolve => {
            this.http.put(this.apiUrl + '/Courses', course)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    addNewCourse(course: any) {
         return new Promise(resolve => {
            this.http.post(this.apiUrl + '/Courses', course)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }

    deleteCourse(course: any) {
         return new Promise(resolve => {
            this.http.delete(this.apiUrl + '/Courses?courseId=' + course.CourseId)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data);
                });
        });
    }
    


}

