SET SERVEROUTPUT ON SIZE 4000


CREATE OR REPLACE FUNCTION IS_AVAILABLE
(
	pactivity_id IN NUMBER,
  pcamp_day IN NUMBER
)
RETURN NUMBER
IS
  f_campday register.camp_day%TYPE;
  f_activityid register.activity_id%TYPE;
BEGIN
    SELECT camp_day INTO f_campday FROM register WHERE camp_day = pcamp_day AND CAMPER_USERNAME = USER;
    SELECT activity_id INTO f_activityid FROM register WHERE activity_ID = pactivity_id AND CAMPER_USERNAME = USER;
    
    IF f_campday IS NOT NULL OR f_activityid IS NOT NULL THEN
      RETURN 1;
    ELSE
      RETURN 0;
    END IF;
END;
/
SHOW ERRORS;