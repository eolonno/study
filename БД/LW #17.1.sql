--Creation of the main procedure
CREATE TABLE CopyToLog
(
    Package VARCHAR (20) NOT NULL,
    Success CHAR NOT NULL CHECK (Success IN ('Y', 'N')),
    CopiedRowsCount NUMERIC(10, 0) NOT NULL,
    InTableName VARCHAR(50) NOT NULL,
    OutTableName VARCHAR(50) NOT NULL,
    EndTime DATE NOT NULL
);

--Table creation and filling AAA table
CREATE TABLE AAA(X NUMERIC(10, 0));
CREATE TABLE BBB(X NUMERIC(10, 0));
BEGIN
    FOR X IN 1..100000
    LOOP
        INSERT INTO AAA VALUES (X);
    END LOOP;
END;

CREATE OR REPLACE PACKAGE CopyTo is
    PROCEDURE CopyToJob(InTableName IN VARCHAR, OutTableName IN VARCHAR, CountOfRowsForCopy IN NUMERIC);
    PROCEDURE CreateCopyToJob(JobNumber USER_JOBS.JOB%TYPE, CountOfRowsForCopy IN NUMERIC);
    PROCEDURE RunCopyToJob(JobNumber USER_JOBS.JOB%TYPE);
    PROCEDURE ConfigureCopyToJob(JobNumber USER_JOBS.JOB%TYPE, IntervalInSeconds IN NUMERIC);
    PROCEDURE PauseCopyToJob(JobNumber USER_JOBS.JOB%TYPE);
    PROCEDURE RemoveCopyToJob(JobNumber USER_JOBS.JOB%TYPE);
    FUNCTION IsJobRunning(JobNumber USER_JOBS.JOB%TYPE) RETURN CHAR;
END CopyTo;
CREATE OR REPLACE PACKAGE BODY CopyTo IS

    PROCEDURE CopyToJob
    (
        InTableName IN VARCHAR,
        OutTableName IN VARCHAR,
        CountOfRowsForCopy IN NUMERIC
    )
    IS
    BEGIN
        EXECUTE IMMEDIATE 'INSERT INTO ' || OutTableName || '(X)' ||
                          ' SELECT ' || InTableName || '.X' ||
                          ' FROM ' || InTableName ||
                          ' WHERE ROWNUM <= ' || CountOfRowsForCopy;
        APEX_UTIL.PAUSE(5);
        EXECUTE IMMEDIATE 'DELETE ' || InTableName || ' WHERE ROWNUM <= ' || CountOfRowsForCopy;
        INSERT INTO CopyToLog VALUES ('CopyTo', 'Y', CountOfRowsForCopy, InTableName, OutTableName, SYSDATE);
        COMMIT;
        EXCEPTION WHEN OTHERS
            THEN  BEGIN
                DBMS_OUTPUT.PUT_LINE(SQLERRM);
                INSERT INTO CopyToLog VALUES ('CopyTo', 'N', 0, InTableName, OutTableName, SYSDATE);
                INSERT INTO CopyToLog VALUES ('CopyTo', 'N', 0, InTableName, OutTableName, SYSDATE);
            END;
    END CopyToJob;

    PROCEDURE CreateCopyToJob
    (
        JobNumber USER_JOBS.JOB%TYPE,
        CountOfRowsForCopy IN NUMERIC
    )
    IS
    BEGIN
        DBMS_JOB.ISUBMIT(JobNumber,
            'CopyTo.CopyToJob(''AAA'', ''BBB'', ' || CountOfRowsForCopy || ');',
            SYSDATE,
            'SYSDATE + 7');
        COMMIT;
    END CreateCopyToJob;

    PROCEDURE RunCopyToJob
    (
        JobNumber USER_JOBS.JOB%TYPE
    )
    IS
    BEGIN
        DBMS_JOB.RUN(JobNumber);
        COMMIT;
    END RunCopyToJob;

    PROCEDURE ConfigureCopyToJob
    (
        JobNumber USER_JOBS.JOB%TYPE,
        IntervalInSeconds IN NUMERIC
    )
    IS
    BEGIN
        DBMS_JOB.INTERVAL(JobNumber, 'SYSDATE + ' || IntervalInSeconds || ' / 86400');
        COMMIT;
    END ConfigureCopyToJob;

    PROCEDURE PauseCopyToJob
    (
        JobNumber USER_JOBS.JOB%TYPE
    )
    IS
    BEGIN
        DBMS_JOB.BROKEN(JobNumber, TRUE, NULL);
        COMMIT;
    END PauseCopyToJob;

    PROCEDURE RemoveCopyToJob
    (
        JobNumber USER_JOBS.JOB%TYPE
    )
    IS
    BEGIN
        DBMS_JOB.REMOVE(JobNumber);
        COMMIT;
    END RemoveCopyToJob;

    FUNCTION IsJobRunning(JobNumber USER_JOBS.JOB%TYPE)
    RETURN CHAR
    IS
        Job USER_JOBS%ROWTYPE;
    BEGIN
        SELECT * INTO Job FROM USER_JOBS WHERE JOB = JobNumber;
        IF Job.THIS_SEC IS NOT NULL
            THEN RETURN 'Y';
        ELSE RETURN 'N';
        END IF;
    END IsJobRunning;
END CopyTo;

CALL CopyTo.CreateCopyToJob(20, 30);
CALL CopyTo.RunCopyToJob(20);
SELECT CopyTo.IsJobRunning(20) FROM DUAL;
CALL CopyTo.ConfigureCopyToJob(20, 60);  --Если нужно сбросить счетчик,
                                                                    -- то необходимо запустить RunCopyToJob,
                                                                    -- чтобы сработала Job, которая уже стоит в расписании
CALL CopyTo.PauseCopyToJob(20);
CALL CopyTo.RemoveCopyToJob(20);

SELECT * FROM USER_JOBS;