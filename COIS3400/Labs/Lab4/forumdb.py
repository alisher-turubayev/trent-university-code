# "Database code" for the DB Forum.

import psycorg2, bleach

def get_posts():
  """Return all posts from the 'database', most recent first."""
  conn = psycorg2.connect(database="forum")
  cursor = conn.cursor()

  cursor.execute("SELECT content, time from posts ORDER BY time DESC")

  results = cursor.fetchall()

  conn.close()

  return results

def add_post(content):
  """Add a post to the 'database' with the current timestamp."""
  conn = psycorg2.connect("dbname=forum")
  cursor = conn.cursor()

  cursor.execute("INSERT INTO forum(content, time, id) VALUES (%s)", bleach.clean(content))
  conn.commit()

  conn.close()
