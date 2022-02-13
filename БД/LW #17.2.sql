CREATE OR REPLACE PACKAGE CopyToScheduler is
    PROCEDURE CopyToJob(InTableName IN VARCHAR, OutTableName IN VARCHAR, CountOfRowsForCopy IN NUMERIC);
    PROCEDURE CreateCopyToJob(JobName IN VARCHAR, CountOfRowsForCopy IN NUMERIC);
    PROCEDURE RunCopyToJob(JobName IN VARCHAR);
    PROCEDURE ConfigureCopyToJob(JobName IN VARCHAR, IntervalInSeconds IN NUMERIC);
    PROCEDURE PauseCopyToJob(JobName IN VARCHAR);
    PROCEDURE RemoveCopyToJob(JobName IN VARCHAR);
    FUNCTION IsJobRunning(JobName IN VARCHAR) RETURN CHAR;
    PROCEDURE StartCopyToJob(JobName IN VARCHAR);
END CopyToScheduler;
CREATE OR REPLACE PACKAGE BODY CopyToScheduler IS

    PROCEDURE CopyToJob
    (
        InTableName IN VARCHAR,
        OutTableName IN VARCHAR,
        CountOfRowsForCopy IN NUMERIC
    )
    IS BEGIN
        EXECUTE IMMEDIATE 'INSERT INTO ' || OutTableName || '(X)' ||
                          ' SELECT ' || InTableName || '.X' ||
                          ' FROM ' || InTableName ||
                          ' WHERE ROWNUM <= ' || CountOfRowsForCopy;
        APEX_UTIL.PAUSE(5);
        EXECUTE IMMEDIATE 'DELETE ' || InTableName || ' WHERE ROWNUM <= ' || CountOfRowsForCopy;
        INSERT INTO CopyToLog VALUES ('CopyToScheduler', 'Y', CountOfRowsForCopy, InTableName, OutTableName, SYSDATE);
        COMMIT;
        EXCEPTION WHEN OTHERS
            THEN  BEGIN
                DBMS_OUTPUT.PUT_LINE(SQLERRM);
                INSERT INTO CopyToLog VALUES ('CopyToScheduler', 'N', 0, InTableName, OutTableName, SYSDATE);
                COMMIT;
            END;
    END CopyToJob;

    PROCEDURE CreateCopyToJob
    (
        JobName IN VARCHAR,
        CountOfRowsForCopy IN NUMERIC
    )
    IS BEGIN
--         DBMS_SCHEDULER.CREATE_JOB_CLASS
--         (
--             JOB_CLASS_NAME => 'CopyToJob',
--             RESOURCE_CONSUMER_GROUP => 'default_consumer_group',
--             LOGGING_LEVEL => DBMS_SCHEDULER.LOGGING_FULL
--         );
        DBMS_SCHEDULER.CREATE_JOB
        (
            JOB_NAME => JobName,
            JOB_TYPE => 'STORED_PROCEDURE',
            JOB_ACTION => 'CopyToScheduler.CopyToJob',
            NUMBER_OF_ARGUMENTS => 3,
            START_DATE => SYSTIMESTAMP,
            REPEAT_INTERVAL => 'FREQ=DAILY; INTERVAL=7',
            ENABLED => FALSE,
            JOB_CLASS => 'CopyToJob'
        );
        DBMS_SCHEDULER.SET_JOB_ARGUMENT_VALUE(JOB_NAME => JobName, ARGUMENT_POSITION => 1, ARGUMENT_VALUE => 'AAA');
        DBMS_SCHEDULER.SET_JOB_ARGUMENT_VALUE(JOB_NAME => JobName, ARGUMENT_POSITION => 2, ARGUMENT_VALUE => 'BBB');
        DBMS_SCHEDULER.SET_JOB_ARGUMENT_VALUE(JOB_NAME => JobName, ARGUMENT_POSITION => 3, ARGUMENT_VALUE => CountOfRowsForCopy);
        DBMS_SCHEDULER.ENABLE(JobName);
        COMMIT;
    END CreateCopyToJob;

    PROCEDURE RunCopyToJob
    (
        JobName IN VARCHAR
    )
    IS
    BEGIN
        DBMS_SCHEDULER.RUN_JOB(JobName);
        COMMIT;
    END RunCopyToJob;

    PROCEDURE ConfigureCopyToJob
    (
        JobName IN VARCHAR,
        IntervalInSeconds IN NUMERIC
    )
    IS BEGIN
        DBMS_SCHEDULER.SET_ATTRIBUTE
        (
            NAME => JobName,
            ATTRIBUTE => 'REPEAT_INTERVAL',
            VALUE => 'FREQ=SECONDLY; INTERVAL=' || IntervalInSeconds
        );
        COMMIT;
    END ConfigureCopyToJob;

    PROCEDURE PauseCopyToJob(JobName IN VARCHAR)
    IS BEGIN
        DBMS_SCHEDULER.DISABLE(JobName);
        COMMIT;
    END PauseCopyToJob;

    PROCEDURE RemoveCopyToJob
    (
        JobName IN VARCHAR
    )
    IS
    BEGIN
        DBMS_SCHEDULER.DROP_JOB(JobName);
        COMMIT;
    END RemoveCopyToJob;

    FUNCTION IsJobRunning(JobName IN VARCHAR)
    RETURN CHAR
    IS
        IsRunning NUMERIC;
    BEGIN
        SELECT COUNT(*) INTO IsRunning FROM USER_SCHEDULER_RUNNING_JOBS WHERE JOB_NAME = JobName;
        IF IsRunning >= 1 AND IsRunning IS NOT NULL
            THEN RETURN 'Y';
        ELSE RETURN 'N';
        END IF;
    END IsJobRunning;

    PROCEDURE StartCopyToJob(JobName IN VARCHAR)
    IS BEGIN
        DBMS_SCHEDULER.ENABLE(JobName);
        COMMIT;
    END;
END CopyToScheduler;

CALL CopyToScheduler.CreateCopyToJob('SomeJob', 20);
CALL CopyToScheduler.RunCopyToJob('SomeJob');
SELECT CopyToScheduler.IsJobRunning('SomeJob') FROM DUAL;
CALL CopyToScheduler.ConfigureCopyToJob('SomeJob', 20);
CALL CopyToScheduler.PauseCopyToJob('SomeJob');
CALL CopyToScheduler.StartCopyToJob('SomeJob');
CALL CopyToScheduler.RemoveCopyToJob('SomeJob');

SELECT * FROM USER_SCHEDULER_JOBS;
SELECT * FROM CopyToLog;
SELECT COUNT(*) FROM AAA;