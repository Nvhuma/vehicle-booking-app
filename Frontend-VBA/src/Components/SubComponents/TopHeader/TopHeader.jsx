import React from 'react'
import { GetUser } from "../../../utils/Auth/Auth";
import styles from './TopHeader.module.css'

function TopHeader() {
  return (
	<div className={styles['top-header-container']}>
		<div className={styles["profiler-container"]}>
			<p className={styles["profiler-email"]}>
				thisguy@email.com
			</p>
			<img src="https://placehold.jp/150x150.png" alt="" className={styles["profiler-image"]} />
		</div>
	</div>
  )
}

export default TopHeader