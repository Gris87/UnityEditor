if [ -z "$1" ]; then
  echo "Usage: ./shared_commit.sh MESSAGE"
else
  . commit.sh "$1"
  . submodule_update.sh
  . commit.sh "Submodule update"
fi
