//
// ===== File globals.ts    
//

    
        import { Home } from '../pages/home/home';
    

    
        import { LetterGrades } from '../pages/lettergrades/lettergrades';
    

    
        import { LetterGrade } from '../pages/lettergrades/lettergrade/lettergrade';
    

    
        import { Courses } from '../pages/courses/courses';
    

    
        import { Course } from '../pages/courses/course/course';
    

    
        import { Assignments } from '../pages/courses/course/assignments/assignments';
    

    
        import { Assignment } from '../pages/courses/course/assignments/assignment/assignment';
    

    
        import { About } from '../pages/about/about';
    

    
        import { Contact } from '../pages/contact/contact';
    

    
        import { Chat } from '../pages/contact/chat/chat';
    

    
        import { Email } from '../pages/contact/email/email';
    

    
        import { Call } from '../pages/contact/call/call';
    


export const components : any[] = [Home, LetterGrades, LetterGrade, Courses, Course, Assignments, Assignment, About, Contact, Chat, Email, Call];

export const siteMap: { [name: string]: { name: string, title: string, component: any, parentComponent: any, subComponents: any[]; } } = {};

                            siteMap['Home'] = { name: 'Home', title: 'Home', component: Home, parentComponent: null, subComponents: [] };
                        
                            siteMap['LetterGrades'] = { name: 'LetterGrades', title: 'LetterGrades', component: LetterGrades, parentComponent: null, subComponents: [] };
                        
                            siteMap['LetterGrade'] = { name: 'LetterGrade', title: 'LetterGrade', component: LetterGrade, parentComponent: null, subComponents: [] };
                        
                            siteMap['Courses'] = { name: 'Courses', title: 'Courses', component: Courses, parentComponent: null, subComponents: [] };
                        
                            siteMap['Course'] = { name: 'Course', title: 'Course', component: Course, parentComponent: null, subComponents: [] };
                        
                            siteMap['Assignments'] = { name: 'Assignments', title: 'Assignments', component: Assignments, parentComponent: null, subComponents: [] };
                        
                            siteMap['Assignment'] = { name: 'Assignment', title: 'Assignment', component: Assignment, parentComponent: null, subComponents: [] };
                        
                            siteMap['About'] = { name: 'About', title: 'About', component: About, parentComponent: null, subComponents: [] };
                        
                            siteMap['Contact'] = { name: 'Contact', title: 'Contact', component: Contact, parentComponent: null, subComponents: [] };
                        
                            siteMap['Chat'] = { name: 'Chat', title: 'Chat', component: Chat, parentComponent: null, subComponents: [] };
                        
                            siteMap['Email'] = { name: 'Email', title: 'Email', component: Email, parentComponent: null, subComponents: [] };
                        
                            siteMap['Call'] = { name: 'Call', title: 'Call', component: Call, parentComponent: null, subComponents: [] };
                        


                                siteMap['LetterGrades'].subComponents.push(siteMap['LetterGrade']);
                            
                                siteMap['LetterGrade'].parentComponent = siteMap['LetterGrades'];
                            
                                siteMap['Courses'].subComponents.push(siteMap['Course']);
                            
                                siteMap['Course'].parentComponent = siteMap['Courses'];
                            
                                siteMap['Course'].subComponents.push(siteMap['Assignments']);
                            
                                siteMap['Assignments'].parentComponent = siteMap['Course'];
                            
                                siteMap['Assignments'].subComponents.push(siteMap['Assignment']);
                            
                                siteMap['Assignment'].parentComponent = siteMap['Assignments'];
                            
                                siteMap['Contact'].subComponents.push(siteMap['Chat']);
                            
                                siteMap['Contact'].subComponents.push(siteMap['Email']);
                            
                                siteMap['Contact'].subComponents.push(siteMap['Call']);
                            
                                siteMap['Chat'].parentComponent = siteMap['Contact'];
                            
                                siteMap['Email'].parentComponent = siteMap['Contact'];
                            
                                siteMap['Call'].parentComponent = siteMap['Contact'];
                            

export const pages : any[] = [

        siteMap['Home']
    , 
        siteMap['LetterGrades']
    , 
        siteMap['Courses']
    , 
        siteMap['About']
    , 
        siteMap['Contact']
    
];

