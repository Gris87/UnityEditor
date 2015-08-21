if [ -z "$1" ]; then
  echo "Usage: ./commit.sh MESSAGE"
else
  git submodule foreach "git add ."
  git submodule foreach "git commit -a -m '$1' || echo Skipped"

  git add .
  git commit -a -m "$1"

  . push.sh
fi
