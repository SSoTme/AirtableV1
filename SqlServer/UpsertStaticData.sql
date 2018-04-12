
 -- INSERT DATA
  
        
        
        
            -- INSERT: LetterGrade
            --  STATIC: true
            --  Rows: 9
            --  only-static-data: true
        
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>rec2FgkGG8ml8KXoc</LetterGradeId><Name>A-</Name><PointMin>90</PointMin><PointMincopy>94</PointMincopy><createdTime>2018-04-12T21:55:53Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'rec2FgkGG8ml8KXoc')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'rec2FgkGG8ml8KXoc', 
                                 'A-', 
                                 '90', 
                                 '94', 
                                 '2018-04-12T21:55:53Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'A-', 
                                PointMin = '90', 
                                PointMincopy = '94', 
                                createdTime = '2018-04-12T21:55:53Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'rec2FgkGG8ml8KXoc';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recGJADpClvSLjg72</LetterGradeId><Name>C</Name><PointMin>70</PointMin><PointMincopy>74</PointMincopy><createdTime>2018-04-12T21:56:48Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recGJADpClvSLjg72')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recGJADpClvSLjg72', 
                                 'C', 
                                 '70', 
                                 '74', 
                                 '2018-04-12T21:56:48Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'C', 
                                PointMin = '70', 
                                PointMincopy = '74', 
                                createdTime = '2018-04-12T21:56:48Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recGJADpClvSLjg72';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recGtQgLIppuI0Auk</LetterGradeId><Name>B-</Name><PointMin>75</PointMin><PointMincopy>79</PointMincopy><createdTime>2018-04-12T21:56:43Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recGtQgLIppuI0Auk')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recGtQgLIppuI0Auk', 
                                 'B-', 
                                 '75', 
                                 '79', 
                                 '2018-04-12T21:56:43Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'B-', 
                                PointMin = '75', 
                                PointMincopy = '79', 
                                createdTime = '2018-04-12T21:56:43Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recGtQgLIppuI0Auk';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recM5pmWZUJexsggR</LetterGradeId><Name>F</Name><PointMin>0</PointMin><PointMincopy>59</PointMincopy><createdTime>2018-04-12T21:56:55Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recM5pmWZUJexsggR')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recM5pmWZUJexsggR', 
                                 'F', 
                                 '0', 
                                 '59', 
                                 '2018-04-12T21:56:55Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'F', 
                                PointMin = '0', 
                                PointMincopy = '59', 
                                createdTime = '2018-04-12T21:56:55Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recM5pmWZUJexsggR';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recPSeuNAMRg7ISJ2</LetterGradeId><Name>B</Name><PointMin>80</PointMin><PointMincopy>54</PointMincopy><createdTime>2018-04-12T21:56:42Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recPSeuNAMRg7ISJ2')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recPSeuNAMRg7ISJ2', 
                                 'B', 
                                 '80', 
                                 '54', 
                                 '2018-04-12T21:56:42Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'B', 
                                PointMin = '80', 
                                PointMincopy = '54', 
                                createdTime = '2018-04-12T21:56:42Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recPSeuNAMRg7ISJ2';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recSSQYDz2EZjetSf</LetterGradeId><Name>D</Name><PointMin>60</PointMin><PointMincopy>69</PointMincopy><createdTime>2018-04-12T21:56:54Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recSSQYDz2EZjetSf')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recSSQYDz2EZjetSf', 
                                 'D', 
                                 '60', 
                                 '69', 
                                 '2018-04-12T21:56:54Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'D', 
                                PointMin = '60', 
                                PointMincopy = '69', 
                                createdTime = '2018-04-12T21:56:54Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recSSQYDz2EZjetSf';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recdMTKd2GCapPWMe</LetterGradeId><PointMincopy>97</PointMincopy><Name>A</Name><PointMin>95</PointMin><Notes>The second best grade.  most people are happy with an A.
</Notes><createdTime>2018-04-12T21:55:53Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recdMTKd2GCapPWMe')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recdMTKd2GCapPWMe', 
                                 'A', 
                                 '95', 
                                 '97', 
                                 '2018-04-12T21:55:53Z', 
                                 'The second best grade.  most people are happy with an A.
');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'A', 
                                PointMin = '95', 
                                PointMincopy = '97', 
                                createdTime = '2018-04-12T21:55:53Z', 
                                Notes = 'The second best grade.  most people are happy with an A.
'
                        WHERE LetterGradeId = 'recdMTKd2GCapPWMe';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recfRXc8fchQUwmGw</LetterGradeId><PointMincopy>100</PointMincopy><Name>A+</Name><PointMin>98</PointMin><Notes>The best grade you can get</Notes><createdTime>2018-04-12T21:55:53Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recfRXc8fchQUwmGw')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recfRXc8fchQUwmGw', 
                                 'A+', 
                                 '98', 
                                 '100', 
                                 '2018-04-12T21:55:53Z', 
                                 'The best grade you can get');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'A+', 
                                PointMin = '98', 
                                PointMincopy = '100', 
                                createdTime = '2018-04-12T21:55:53Z', 
                                Notes = 'The best grade you can get'
                        WHERE LetterGradeId = 'recfRXc8fchQUwmGw';
                    END
                

                    -- INSERT VALUES
                    /* <LetterGrade><LetterGradeId>recrOPP0ptXl7tpQh</LetterGradeId><Name>B+</Name><PointMin>85</PointMin><PointMincopy>89</PointMincopy><createdTime>2018-04-12T21:56:42Z</createdTime></LetterGrade> */
                    IF NOT EXISTS (SELECT LetterGradeId FROM LetterGrade WHERE LetterGradeId = 'recrOPP0ptXl7tpQh')
                    BEGIN
                        INSERT INTO [LetterGrade] (LetterGradeId , Name , PointMin , PointMincopy , createdTime , Notes ) VALUES (
                                 'recrOPP0ptXl7tpQh', 
                                 'B+', 
                                 '85', 
                                 '89', 
                                 '2018-04-12T21:56:42Z', 
                                 '');
                    END ELSE BEGIN
                        UPDATE  [LetterGrade] 
                            SET 
                                Name = 'B+', 
                                PointMin = '85', 
                                PointMincopy = '89', 
                                createdTime = '2018-04-12T21:56:42Z', 
                                Notes = ''
                        WHERE LetterGradeId = 'recrOPP0ptXl7tpQh';
                    END
                
            
 
        
        
        
            -- INSERT: Assignment
            --  STATIC: 
            --  Rows: 4
            --  only-static-data: true
        -- VALUES ignored because they are not marked as IsStatic in the airtable.
 
        
        
        
            -- INSERT: Course
            --  STATIC: 
            --  Rows: 3
            --  only-static-data: true
        -- VALUES ignored because they are not marked as IsStatic in the airtable.
 
                