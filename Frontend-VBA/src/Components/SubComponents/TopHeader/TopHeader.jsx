import React, { useEffect, useState } from 'react'
import { GetUser } from "../../../utils/Auth/Auth";
import styles from './TopHeader.module.css'

function TopHeader() {

	const [user, setUser] = useState({});

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = GetUser();
        setUser(response);
      } catch (error) {
        console.error("Error fetching user data:", error);
      }
    };

    fetchUserData();
  }, [user]);


  return (
	<div className={styles['top-header-container']}>
		<div className={styles["profiler-container"]}>
			<div className={styles["profiler-details"]}>
				<p className={styles["profiler-name"]}>
					{user.fullName || "user user"}
				</p>
				<p className={styles["profiler-email"]}>
					{user.email || "user@example.com"}
				</p>
			</div>
			<img src="https://placehold.jp/150x150.png" alt="" className={styles["profiler-image"]} />
		</div>
	</div>
  )
}

export default TopHeader